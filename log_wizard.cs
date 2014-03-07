using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace LogWizard
{
    public partial class LogWizard : Form
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static List<LogWizard> forms = new List<LogWizard>();

        public class filter {
            public string name = "";
            public string text = "";
        }
        private class view {
            // friendlly name
            public string name = "";
            // enabled, used, index-of-filter -> see which filters are used in this view
            public List< Tuple<bool, bool> > filters = new List<Tuple<bool,bool>>();

            public void copy_from(view other) {
                name = other.name;
                filters = other.filters.ToList();
            }
        }
        private class context {
            public string name  = "";
            public string auto_match = "";
            public List<view> views = new List<view>();

            public void copy_from(context other) {
                name = other.name;
                auto_match = other.auto_match;
                views = other.views.ToList();
            }
        }

        private class history {
            // 0->file, 1->shmem
            public int type;
            public string name = "";
            public string friendly_name = "";
            public string log_syntax  = "";

            public string combo_name { get {
                if ( friendly_name != "") return friendly_name;
                switch ( type) {
                    case 0: return name; // the name of the type
                    case 1: return "Shared Memory: " + name;
                    default: Debug.Assert(false); break;
                }
                return "invalid";
            }}
        }
        
        private static List<filter> log_filters = new List<filter>();
        private static List<context> log_contexts = new List<context>();

        private static List<history> log_history = new List<history>();

        private settings_file sett = Program.sett;
        // the selected filter's text
        private string sel_filter_name = "";

        private log_reader reader = null;

        const int MAX_HISTORY_ENTRIES = 100;

        private bool ignore_change = false;


        public LogWizard(bool show_filters_ = true, bool show_source_ = true, bool show_full_log_ = false)
        {
            InitializeComponent();
            forms.Add(this);
            filtersCtrl.ShowGroups = false;
            show_filters(show_filters_);
            show_source(show_source_);
            show_full_log(show_full_log_);
            sourceTypeCtrl.SelectedIndex = 0;
            bool first_time = log_contexts.Count == 0;
            if ( first_time) 
                load_contexts();                
            
            ignore_change = true;

            foreach ( context ctx in log_contexts)
                curContextCtrl.Items.Add(ctx.name);
            // just select something
            curContextCtrl.SelectedIndex = 0;

            foreach ( history hist in log_history)
                logHistory.Items.Add(hist.combo_name);

            load();
            ignore_change = false;

            if ( log_history.Count > 0) 
                logHistory.SelectedIndex = log_history.Count - 1;
        }

        private context cur_context() { 
            return log_contexts[ curContextCtrl.SelectedIndex];
        }

        private void load_contexts() {
            logger.Debug("loading contexts");
            int filter_count = int.Parse( sett.get("filter_count", "1"));
            for (int idx = 0; idx < filter_count; ++idx) {
                filter filt = new filter();
                filt.name = sett.get("filter." + idx + "name");
                filt.text = sett.get("filter." + idx + "text");
                log_filters.Add(filt);
            }

            int history_count = int.Parse( sett.get("history_count", "0"));
            for (int idx = 0; idx < history_count; ++idx) {
                history hist = new history();
                hist.type = int.Parse( sett.get("history." + idx + "type", "0"));
                hist.name = sett.get("history." + idx + "name");
                hist.friendly_name = sett.get("history." + idx + "friendly_name");
                hist.log_syntax = sett.get("history." + idx + "log_syntax");
                log_history.Add( hist );
            }

            int count = int.Parse( sett.get("context_count", "1"));
            for ( int i = 0; i < count ; ++i) {
                context ctx = new context();
                ctx.name = sett.get("context." + i + ".name", "Default");
                ctx.auto_match = sett.get("context." + i + ".auto_match");
                int view_count = int.Parse( sett.get("context." + i + ".view_count", "1"));
                for ( int v = 0; v < view_count; ++v) {
                    view lv = new view();
                    lv.name = sett.get("context." + i + ".view" + v + ".name");
                    for ( int f = 0; f < log_filters.Count; ++f) {
                        string prefix = "context." + i + ".view" + v + ".filt" + f + ".";
                        bool enabled = int.Parse( sett.get(prefix + "enabled", "0")) != 0;
                        bool used = int.Parse( sett.get(prefix + "used", "0")) != 0;
                        lv.filters.Add( new Tuple<bool,bool>(enabled,used));
                    }
                    ctx.views.Add(lv);
                }
                log_contexts.Add(ctx);
            }
        }

        private void save_contexts() {
            sett.set( "filter_count", "" + log_filters.Count);
            for ( int idx = 0; idx < log_filters.Count; ++idx) {
                sett.set("filter." + idx + "name", log_filters[idx].name);
                sett.set("filter." + idx + "text", log_filters[idx].text);
            }

            sett.set( "history_count", "" + log_history.Count);
            for ( int idx = 0; idx < log_history.Count; ++idx) {
                sett.set("history." + idx + "type", "" + log_history[idx].type);
                sett.set("history." + idx + "name", log_history[idx].name);
                sett.set("history." + idx + "friendly_name", log_history[idx].friendly_name);
                sett.set("history." + idx + "log_syntax", log_history[idx].log_syntax);
            }

            sett.set("context_count", "" + log_contexts.Count);
            for ( int i = 0; i < log_contexts.Count; ++i) {
                sett.set("context." + i + ".name", log_contexts[i].name);
                sett.set("context." + i + ".auto_match", log_contexts[i].auto_match);
                sett.set("context." + i + ".view_count", "" + log_contexts[i].views.Count);
                for ( int v = 0; v < log_contexts[i].views.Count; ++v) {
                    view lv = log_contexts[i].views[v];
                    sett.set("context." + i + ".view" + v + ".name", lv.name);
                    for ( int f = 0; f < lv.filters.Count; ++f) {
                        string prefix = "context." + i + ".view" + v + ".filt" + f + ".";
                        sett.set(prefix + "enabled", lv.filters[f].Item1 ? "1" : "0");
                        sett.set(prefix + "used", lv.filters[f].Item2 ? "1" : "0");
                    }
                }
            }
        }

        private bool filters_shown { get { return toggleFilters.Text[0] == '-'; }}
        private bool source_shown { get { return toggleSource.Text[0] == '-'; }}

        private void show_filters(bool show) {
            toggleFilters.Text = show ? "-F" : "+F";
            if ( show) {
                main.Panel1Collapsed = false;
                main.Panel1.Show();
            }
            else {
                main.Panel1Collapsed = true;
                main.Panel1.Hide();
            }

        }
        private void show_source(bool show) {
            toggleSource.Text = show ? "-S" : "+S";
            if ( show) {
                sourceUp.Panel1Collapsed = false;
                sourceUp.Panel1.Show();
            }
            else {
                sourceUp.Panel1Collapsed = true;
                sourceUp.Panel1.Hide();
            }
            if ( curContextCtrl.SelectedIndex >= 0)
                for ( int i = 0; i < cur_context().views.Count; ++i) {
                    log_view lv = log_view_for_tab(i);
                    if ( lv != null)
                        lv.show_name(show);
                }
        }
        private void show_full_log(bool show) {
            toggleFullLog.Text = show ? "-L" : "+L";
            if ( show) {
                filteredLeft.Panel2Collapsed = false;
                filteredLeft.Panel2.Show();
            }
            else {
                filteredLeft.Panel2Collapsed = true;
                filteredLeft.Panel2.Hide();
            }
        }

        private void filteredViews_DragEnter(object sender, DragEventArgs e)
        {
            if ( e.Data.GetDataPresent( DataFormats.FileDrop))
                e.Effect = e.AllowedEffect;
            else
                e.Effect = DragDropEffects.None;
        }

        private void filteredViews_DragDrop(object sender, DragEventArgs e)
        {
            if ( e.Data.GetDataPresent( DataFormats.FileDrop)) {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if ( files.Length == 1)
                    on_file_drop(files[0]);
            }
        }

        private void on_file_drop(string file) {
            ignore_change = true;
            sourceNameCtrl.Text = file;
            sourceTypeCtrl.SelectedIndex = 0;
            friendlyNameCtrl.Text = "";
            logSyntaxCtrl.Text = "";
            ignore_change = false;
            // this will force us to process this change
            last_sel = -2;
            sourceName_TextChanged(null,null);
        }


        private void toggleFilters_Click(object sender, EventArgs e)
        {
            show_filters( toggleFilters.Text[0] == '+');
        }

        private void toggleSource_Click(object sender, EventArgs e)
        {
            show_source( toggleSource.Text[0] == '+');
        }

        private void toggleFullLog_Click(object sender, EventArgs e)
        {
            show_full_log( toggleFullLog.Text[0] == '+');
        }

        private void newView_Click(object sender, EventArgs e)
        {
            new LogWizard( toggleFilters.Text[0] == '-', toggleSource.Text[0] == '-', toggleFullLog.Text[0] == '-').Show();
        }

        private void LogNinja_FormClosed(object sender, FormClosedEventArgs e)
        {
            forms.Remove(this);
            if ( forms.Count == 0)
                Application.Exit();
        }

        class item {
            public bool enabled = true;
            public bool used = true;
            public string name = "";
            public string text = "";
        }

        private void load_filters() {
            // filter Enabled / Used - are context dependent!
            string old_sel = filtersCtrl.SelectedObject != null ? ((item)filtersCtrl.SelectedObject).name : "";

            int count = int.Parse( sett.get("filter_count", "0"));
            List<object> items = new List<object>();
            context cur = cur_context();
            int cur_view = filteredViewsCtrl.SelectedIndex;
            for (int idx = 0; idx < log_filters.Count ; ++idx) {
                item i = new item();
                i.name = log_filters[idx].name;
                i.text = log_filters[idx].text;
                // enabled + used - taken from the current context + currently selected tab
                Debug.Assert( cur.views[cur_view].filters.Count == log_filters.Count);
                i.enabled = cur.views[cur_view].filters[idx].Item1 ;
                i.used = cur.views[cur_view].filters[idx].Item2;
                items.Add(i);
            }
            filtersCtrl.SetObjects(items);
            if ( old_sel != "")
                select_filter(old_sel);
        }

        private void save_filters() {
            // see that we're in sync
            Debug.Assert( filtersCtrl.GetItemCount() == log_filters.Count);

            // filter Enabled / Used - are context dependent!
            context cur = cur_context();
            int cur_view = filteredViewsCtrl.SelectedIndex;

            int count = filtersCtrl.GetItemCount();
            sett.set("filter_count", "" + count);
            for ( int idx = 0; idx < count; ++idx) {
                item i = (item)filtersCtrl.GetItem(idx).RowObject;

                // enabled + used - taken from the current context + currently selected tab
                Debug.Assert( cur.views[cur_view].filters.Count == log_filters.Count);
                cur.views[cur_view].filters[idx] = new Tuple<bool,bool>(i.enabled, i.used);
            }
        }

        private void ensure_we_have_log_view_for_tab(int idx) {
            if ( reader == null)
                return;
            TabPage tab = filteredViewsCtrl.TabPages[idx];
            foreach ( Control c in tab.Controls)
                if ( c is log_view)
                    return; // we have it

            foreach ( Control c in tab.Controls)
                c.Visible = false;

            log_view new_ = new log_view( this, filteredViewsCtrl.TabPages[idx].Text );
            new_.Dock = DockStyle.Fill;
            tab.Controls.Add(new_);
            new_.show_name(source_shown);
        }

        public void on_view_name_changed(log_view view, string name) {
            context cur = cur_context();
            for ( int i = 0; i < cur_context().views.Count; ++i)
                if ( log_view_for_tab(i) == view) {
                    filteredViewsCtrl.TabPages[i].Text = name;
                    cur.views[i].name = name;
                }
        }

        private log_view log_view_for_tab(int idx) {
            TabPage tab = filteredViewsCtrl.TabPages[idx];
            foreach ( Control c in tab.Controls)
                if ( c is log_view)
                    return (log_view)c; // we have it
            return null;
        }

        private void load_tabs() {
            // note: we only add the inner view when there's some source to read from
            context cur = cur_context();
            for ( int idx = 0; idx < cur.views.Count; ++idx) {
                if ( filteredViewsCtrl.TabCount < idx + 1) 
                    filteredViewsCtrl.TabPages.Add(cur.views[idx].name);
                filteredViewsCtrl.TabPages[idx].Text = cur.views[idx].name;
                ensure_we_have_log_view_for_tab(idx);
            }

            while ( filteredViewsCtrl.TabCount > cur.views.Count)
                filteredViewsCtrl.TabPages.RemoveAt(cur.views.Count);
        }

        private void newFilteredView_Click(object sender, EventArgs e)
        {
            context cur = cur_context();
            view new_ = new view() { name = "New_" + cur.views.Count };
            for ( int i = 0; i < log_filters.Count; ++i)
                new_.filters.Add( new Tuple<bool,bool>(false,false));
            cur.views.Add( new_ );
            filteredViewsCtrl.TabPages.Add(new_.name);
            ensure_we_have_log_view_for_tab( cur.views.Count - 1);
        }

        private void delFilteredView_Click(object sender, EventArgs e)
        {
            int idx = filteredViewsCtrl.SelectedIndex;
            if ( idx < 0)
                return;

            context cur = cur_context();
            cur.views.RemoveAt(idx);
            filteredViewsCtrl.TabPages.RemoveAt(idx);
        }

        private void select_filter(string name) {
            for ( int idx = 0; idx < filtersCtrl.GetItemCount(); ++idx) {
                item i = (item)filtersCtrl.GetItem(idx).RowObject;
                if ( i.name == name)
                    filtersCtrl.SelectedIndex = idx;
            }
        }

        private void load() {
            load_tabs();
            load_filters();
        }


        private void save() {
            context cur = cur_context();
            cur.auto_match = contextMatch.Text;

            save_filters();
            save_contexts();

            if ( !Program.sett.dirty)
                // no change
                return;

            Program.sett.save();
            foreach ( LogWizard lw in forms)
                if ( lw != this)
                    lw.load();
        }


        private void filters_SelectionChanged(object sender, EventArgs e)
        {
            item sel = filtersCtrl.SelectedObject != null ? ((item)filtersCtrl.SelectedObject) : null;
            curFilterCtrl.Text = sel != null ? sel.text : "";
            sel_filter_name = sel != null ? sel.name : ""; 
            curFilterCtrl.Enabled = sel != null;
        }

        private void addFilter_Click(object sender, EventArgs e)
        {
            item new_ = new item { enabled = true, used = true, name = "", text = "" };
            
            // keep our internal log filters in sync
            log_filters.Add(new filter());
            foreach ( context ctx in log_contexts)
                foreach ( view lv in ctx.views)
                    // we enable all filters, so that we show as little info as possible
                    // we don't want the "clog" the application - then the user can tweak the filters as he pleases
                    lv.filters.Add( new Tuple<bool,bool>(true,true));

            filtersCtrl.AddObject(new_);
            filtersCtrl.SelectObject(new_);
            curFilterCtrl.Text = "";
            curFilterCtrl.Focus();
        }

        private void delFilter_Click(object sender, EventArgs e)
        {
            item sel = filtersCtrl.SelectedObject != null ? ((item)filtersCtrl.SelectedObject) : null;
            if ( sel != null) {
                int idx = filtersCtrl.SelectedIndex;

                // keep our internal log filters in sync
                log_filters.RemoveAt(idx);
                foreach ( context ctx in log_contexts)
                    foreach ( view lv in ctx.views)
                        lv.filters.RemoveAt(idx);

                filtersCtrl.RemoveObject(sel);
            }
        }

        private void curFilter_TextChanged(object sender, EventArgs e)
        {
            if ( filtersCtrl.GetItemCount() == 0) {
                // this will in turn call us again
                addFilter_Click(null,null);
                return;
            }
            item sel = filtersCtrl.SelectedObject != null ? ((item)filtersCtrl.SelectedObject) : null;
            if ( sel == null) 
                return;

            if ( sel_filter_name == sel.text) {
                // this means we haven't set a name for this filter yet - just use whatever we find in the text
                sel.text = sel_filter_name = curFilterCtrl.Text;
                // ... as name - just the first line
                string name = sel.text.IndexOf("\r") >= 0 ? sel.text.Substring(0, sel.text.IndexOf("\r")) : sel.text;
                sel.name = name;
                filtersCtrl.RefreshObject(sel);
            }
        }

        private void refresh_Tick(object sender, EventArgs e)
        {
            if ( curContextCtrl.DroppedDown)
                return;
            save();
            refresh_cur_log_view();
        }

        private void refresh_cur_log_view() {
            log_view lv = log_view_for_tab(filteredViewsCtrl.SelectedIndex);
            if ( lv != null) {
                Debug.Assert( reader != null);
                lv.set_reader(reader);
                update_filter(lv);
                lv.refresh();
            }
        }

        private void update_filter( log_view lv) {
            List<log_view.filter> lvf = new List<log_view.filter>();
            int count = filtersCtrl.GetItemCount();
            for ( int idx = 0; idx < count; ++idx) {
                item i = (item)filtersCtrl.GetItem(idx).RowObject;
                log_view.filter filt = null;
                if ( i.enabled || i.used) {
                    filt = new log_view.filter();
                    foreach ( string line in i.text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)) {
                        log_view.filter_item item = log_view.filter_item.parse(line);
                        if ( item != null)
                            filt.items.Add(item);
                        log_view.addition add = log_view.addition.parse(line);
                        if ( add != null)
                            filt.additions.Add(add);
                    }
                }

                // basically this is what "Used" means - dim this filter compared to the rest
                if ( !i.enabled && i.used) 
                    foreach ( log_view.filter_item item in filt.items) {
                        item.fg = Color.LightGray;
                        item.bg = Color.White;
                    }

                if ( filt != null && filt.items.Count > 0)
                    lvf.Add(filt);
            }

            lv.set_filters(lvf);
        }

        private void sourceName_TextChanged(object sender, EventArgs e)
        {
            if ( ignore_change)
                return;
            if ( logHistory.DroppedDown)
                // user is going through the history, hasn't made up his mind yet
                return;

            if ( sourceTypeCtrl.SelectedIndex == 0 && File.Exists(sourceNameCtrl.Text)) {
                reader = new file_log_reader(sourceNameCtrl.Text);
                on_new_reader();
                if ( logSyntaxCtrl.Text == "")
                    logSyntaxCtrl.Text = ((file_log_reader)reader).try_to_find_log_syntax();
            }
            else if ( sourceTypeCtrl.SelectedIndex == 1) {
                if ( reader != null && !(reader is shared_memory_log_reader)) 
                    reader = new shared_memory_log_reader();
                ((shared_memory_log_reader)reader).set_memory_name( sourceNameCtrl.Text);
                on_new_reader();
            }
        }

        private void sourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( sourceTypeCtrl.SelectedIndex == 2) {
                reader = new debug_log_reader();
                on_new_reader();
            }
        }

        private int last_sel = -1;
        private void on_new_reader() {
            if ( logHistory.SelectedIndex == last_sel)
                // note: sometimes this gets called twice - for instance, when user drops the combo and then selects an entry with the mouse
                return;
            last_sel = logHistory.SelectedIndex;
            add_reader_to_history();
            context cur = cur_context();
            for ( int idx = 0; idx < cur.views.Count; ++idx)
                ensure_we_have_log_view_for_tab(idx);

            logger.Info("new reader " + log_history[logHistory.SelectedIndex].name);
        }

        private void add_reader_to_history() {
            if ( reader is debug_log_reader)
                return;
            history new_ = new history();
            if ( reader is file_log_reader) {
                new_.name = ((file_log_reader)reader).file;
                new_.type = 0;
            }
            else if ( reader is shared_memory_log_reader) {
                new_.name = ((shared_memory_log_reader)reader).name;
                new_.type = 1;
            }
            else
                Debug.Assert(false);

            int history_idx = -1;
            for ( int i = 0; i < log_history.Count && history_idx < 0; ++i)
                if ( new_.name == log_history[i].name && new_.type == log_history[i].type) 
                    history_idx = i;
            if ( history_idx < 0) {
                log_history.Add(new_);
                history_idx = log_history.Count - 1;
                logHistory.Items.Add(new_.combo_name);
            }
            else {
                ignore_change = true;
                friendlyNameCtrl.Text = log_history[ history_idx].friendly_name;
                logSyntaxCtrl.Text = log_history[ history_idx].log_syntax;
                ignore_change = false;
            }

            ignore_change = true;
            logHistory.SelectedIndex = history_idx;
            ignore_change = false;
            update_history();
        }

        private void update_history() {
            int history_idx = logHistory.SelectedIndex;
            ignore_change = true;
            logHistory.Items.Clear();
            foreach ( history hist in log_history)
                logHistory.Items.Add(hist.combo_name);
            logHistory.SelectedIndex = history_idx;
            ignore_change = false;
        }

        private void logHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( ignore_change || logHistory.SelectedIndex < 0)
                return;

            sourceTypeCtrl.SelectedIndex = log_history[ logHistory.SelectedIndex].type;
            sourceNameCtrl.Text = log_history[ logHistory.SelectedIndex].name;
            friendlyNameCtrl.Text = log_history[ logHistory.SelectedIndex].friendly_name;
            logSyntaxCtrl.Text = log_history[ logHistory.SelectedIndex].log_syntax;
            sourceName_TextChanged(null,null);
        }

        private void friendlyName_TextChanged(object sender, EventArgs e)
        {
            if ( ignore_change)
                return;
            log_history[ logHistory.SelectedIndex].friendly_name = friendlyNameCtrl.Text;
            update_history();
            save();
        }

        private void logSyntax_TextChanged(object sender, EventArgs e)
        {
            if ( ignore_change)
                return;
            log_history[ logHistory.SelectedIndex].log_syntax = logSyntaxCtrl.Text;
            save();
        }

        private void LogWizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            save();
        }

        private void logHistory_DropDownClosed(object sender, EventArgs e)
        {
            //sourceName_TextChanged(null,null);
        }

        private void filteredViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_filters();
        }

        private void toggleTips_Click(object sender, EventArgs e)
        {
            tip.Active = toggleTips.Text[0] == '+';
            toggleTips.Text = toggleTips.Text[0] == '-' ? "+T" : "-T";
        }

        private void addContext_Click(object sender, EventArgs e)
        {
            new_context_form new_ = new new_context_form();
            new_.Location = Cursor.Position;
            if ( new_.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                context new_ctx = new context();
                new_ctx.copy_from( cur_context());
                new_ctx.name = new_.name.Text;
                log_contexts.Add(new_ctx);
                curContextCtrl.Items.Add( new_ctx.name);
                curContextCtrl.SelectedIndex = curContextCtrl.Items.Count - 1;
            }
        }

        private void delContext_Click(object sender, EventArgs e)
        {
            // make sure we have at least one!
        }

        private void curContextCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            load();
            filteredViewsCtrl.SelectedIndex = 0;
            refresh_cur_log_view();
            save();
        }

        private void curContextCtrl_DropDown(object sender, EventArgs e)
        {
            // saving after the selection is changed would be too late
            save();
        }

        private void filtersCtrl_ItemsChanged(object sender, BrightIdeasSoftware.ItemsChangedEventArgs e)
        {
            if ( ignore_change)
                return;
            save();
        }

    }
}
