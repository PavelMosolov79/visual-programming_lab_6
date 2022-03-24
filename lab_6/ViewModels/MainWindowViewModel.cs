using Avalonia.Interactivity;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using lab_6.Models;

namespace lab_6.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        bool is_editing_existing = false;
        string title = "";
        string description = "";
        Planner current = null;
        DateTimeOffset date = DateTimeOffset.Now.Date;
        private Dictionary<DateTimeOffset, List<Planner>> ListsOnDays;
        ViewModelBase content;

        public MainWindowViewModel() {
            this.ListsOnDays = new Dictionary<DateTimeOffset, List<Planner>>();
            this.Items = new ObservableCollection<Planner>();
            this.Handler = new PlannerMainWindow();
        }

        public ViewModelBase Handler {
            private set => this.RaiseAndSetIfChanged(ref content, value);
            get => content;
        }

        public String Title {
            set {
                this.RaiseAndSetIfChanged(ref title, value);
            }
            get { 
                return title;
            }
        }

        public String Description {
            set {
                this.RaiseAndSetIfChanged(ref description, value);
            }

            get  {
                return description;
            }
        }

        public DateTimeOffset Date {
            set {
                this.RaiseAndSetIfChanged(ref date, value);
                this.ChangeObservableCollection(this.date);
            }

            get {
                return this.date;
            }
        }

        public ObservableCollection<Planner> Items {
            set;
            get;
        }

        private void InitPlannerList() {
            var ListsOnDays = new Dictionary<DateTimeOffset, List<Planner>>();
            ListsOnDays.Add(this.date, new List<Planner>());
            this.ListsOnDays = ListsOnDays;
        }

        public void AppendNote(DateTimeOffset date, Planner item) {
            if (!this.ListsOnDays.ContainsKey(date)) {
                this.ListsOnDays.Add(date, new List<Planner>());
            }
            this.ListsOnDays[date].Add(item);
            this.ChangeObservableCollection(this.Date);
        }

        public void ChangeView()
        {
            if (this.Handler is PlannerMainWindow) {
                this.Handler = new NoteWindow();

            }
            else {
                this.Title = "";
                this.Description = "";
                this.current = null;
                this.is_editing_existing = false;
                this.Handler = new PlannerMainWindow();
            }
        }

        public void ChangeObservableCollection(DateTimeOffset date) {
            if (!this.ListsOnDays.ContainsKey(date)) {
                this.Items.Clear();
            }
            else {
                this.Items.Clear();
                foreach (var item in this.ListsOnDays[date]) {
                    this.Items.Add(item);
                }
            }
        }

        public void Save() {
            if (this.Title != "") {
                if (this.is_editing_existing) {
                    var item = this.ListsOnDays[date].Find(x => x.Equals(this.current));
                    item.Title = this.Title;
                    item.Description = this.Description;
                    this.is_editing_existing = false;
                }
                else {
                    this.AppendNote(this.Date, new Planner(this.Title, this.Description));
                }
                this.ChangeView();
            }
        }

        public void Delete(Planner item) {
            this.ListsOnDays[date].Remove(item);
            this.ChangeObservableCollection(date);
        }

        public void ViewExisting(Planner item) {
            this.is_editing_existing = true;
            this.current = item;
            this.Title = current.Title;
            this.Description = current.Description;
            this.ChangeView();
        }
    }
}
