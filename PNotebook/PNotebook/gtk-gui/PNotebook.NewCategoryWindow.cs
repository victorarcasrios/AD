
// This file has been generated by the GUI designer. Do not modify.
namespace PNotebook
{
	public partial class NewCategoryWindow
	{
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label categoryNameLabel;
		private global::Gtk.Entry categoryNameEntry;
		private global::Gtk.Button createCategoryButton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget PNotebook.NewCategoryWindow
			this.Name = "PNotebook.NewCategoryWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("NewRecordWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child PNotebook.NewCategoryWindow.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.categoryNameLabel = new global::Gtk.Label ();
			this.categoryNameLabel.Name = "categoryNameLabel";
			this.categoryNameLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Nombre nueva categoria:");
			this.hbox1.Add (this.categoryNameLabel);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.categoryNameLabel]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.categoryNameEntry = new global::Gtk.Entry ();
			this.categoryNameEntry.CanFocus = true;
			this.categoryNameEntry.Name = "categoryNameEntry";
			this.categoryNameEntry.IsEditable = true;
			this.categoryNameEntry.InvisibleChar = '•';
			this.hbox1.Add (this.categoryNameEntry);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.categoryNameEntry]));
			w2.Position = 1;
			// Container child hbox1.Gtk.Box+BoxChild
			this.createCategoryButton = new global::Gtk.Button ();
			this.createCategoryButton.CanFocus = true;
			this.createCategoryButton.Name = "createCategoryButton";
			this.createCategoryButton.UseUnderline = true;
			this.createCategoryButton.Label = global::Mono.Unix.Catalog.GetString ("Crear");
			this.hbox1.Add (this.createCategoryButton);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.createCategoryButton]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			this.Add (this.hbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 423;
			this.DefaultHeight = 53;
			this.Show ();
		}
	}
}
