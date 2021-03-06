
// This file has been generated by the GUI designer. Do not modify.
namespace PNotebook
{
	public partial class NewArticleWindow
	{
		private global::Gtk.VBox vbox1;
		private global::Gtk.HBox hbox8;
		private global::Gtk.Label articleNameLabel;
		private global::Gtk.Entry articleNameEntry;
		private global::Gtk.HBox hbox9;
		private global::Gtk.Label articleCategoryLabel;
		private global::Gtk.ComboBox articleCategoryCombobox;
		private global::Gtk.HBox hbox10;
		private global::Gtk.Label priceCategoryLabel;
		private global::Gtk.Entry articlePriceEntry;
		private global::Gtk.HBox hbox11;
		private global::Gtk.Button createArticleButton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget PNotebook.NewArticleWindow
			this.Name = "PNotebook.NewArticleWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("Crear nuevo articulo");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child PNotebook.NewArticleWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.articleNameLabel = new global::Gtk.Label ();
			this.articleNameLabel.Name = "articleNameLabel";
			this.articleNameLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Nombre:");
			this.hbox8.Add (this.articleNameLabel);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.articleNameLabel]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.articleNameEntry = new global::Gtk.Entry ();
			this.articleNameEntry.CanFocus = true;
			this.articleNameEntry.Name = "articleNameEntry";
			this.articleNameEntry.IsEditable = true;
			this.articleNameEntry.InvisibleChar = '•';
			this.hbox8.Add (this.articleNameEntry);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.articleNameEntry]));
			w2.Position = 1;
			this.vbox1.Add (this.hbox8);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox8]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox9 = new global::Gtk.HBox ();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 6;
			// Container child hbox9.Gtk.Box+BoxChild
			this.articleCategoryLabel = new global::Gtk.Label ();
			this.articleCategoryLabel.Name = "articleCategoryLabel";
			this.articleCategoryLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Categoria:");
			this.hbox9.Add (this.articleCategoryLabel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.articleCategoryLabel]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox9.Gtk.Box+BoxChild
			this.articleCategoryCombobox = global::Gtk.ComboBox.NewText ();
			this.articleCategoryCombobox.Name = "articleCategoryCombobox";
			this.hbox9.Add (this.articleCategoryCombobox);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.articleCategoryCombobox]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox1.Add (this.hbox9);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox9]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox10 = new global::Gtk.HBox ();
			this.hbox10.Name = "hbox10";
			this.hbox10.Spacing = 6;
			// Container child hbox10.Gtk.Box+BoxChild
			this.priceCategoryLabel = new global::Gtk.Label ();
			this.priceCategoryLabel.Name = "priceCategoryLabel";
			this.priceCategoryLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Precio:");
			this.hbox10.Add (this.priceCategoryLabel);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox10 [this.priceCategoryLabel]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox10.Gtk.Box+BoxChild
			this.articlePriceEntry = new global::Gtk.Entry ();
			this.articlePriceEntry.CanFocus = true;
			this.articlePriceEntry.Name = "articlePriceEntry";
			this.articlePriceEntry.IsEditable = true;
			this.articlePriceEntry.InvisibleChar = '•';
			this.hbox10.Add (this.articlePriceEntry);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox10 [this.articlePriceEntry]));
			w8.Position = 1;
			this.vbox1.Add (this.hbox10);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox10]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox11 = new global::Gtk.HBox ();
			this.hbox11.Name = "hbox11";
			this.hbox11.Spacing = 6;
			// Container child hbox11.Gtk.Box+BoxChild
			this.createArticleButton = new global::Gtk.Button ();
			this.createArticleButton.CanFocus = true;
			this.createArticleButton.Name = "createArticleButton";
			this.createArticleButton.UseUnderline = true;
			this.createArticleButton.Label = global::Mono.Unix.Catalog.GetString ("Crear artículo");
			this.hbox11.Add (this.createArticleButton);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox11 [this.createArticleButton]));
			w10.Position = 2;
			w10.Expand = false;
			w10.Fill = false;
			this.vbox1.Add (this.hbox11);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox11]));
			w11.Position = 3;
			w11.Expand = false;
			w11.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
		}
	}
}
