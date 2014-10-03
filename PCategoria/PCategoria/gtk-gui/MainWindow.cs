
// This file has been generated by the GUI designer. Do not modify.
public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action addAction;
	private global::Gtk.Action refreshAction;
	private global::Gtk.Action deleteAction;
	private global::Gtk.VBox vbox1;
	private global::Gtk.Toolbar toolbar1;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.TreeView treeView;
	private global::Gtk.HBox hbox1;
	private global::Gtk.Entry nameInput;
	private global::Gtk.Button AddButton;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.addAction = new global::Gtk.Action ("addAction", null, null, "gtk-add");
		w1.Add (this.addAction, null);
		this.refreshAction = new global::Gtk.Action ("refreshAction", null, null, "gtk-refresh");
		w1.Add (this.refreshAction, null);
		this.deleteAction = new global::Gtk.Action ("deleteAction", global::Mono.Unix.Catalog.GetString ("_Eliminar"), null, "gtk-delete");
		this.deleteAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Eliminar");
		w1.Add (this.deleteAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='addAction' action='addAction'/><toolitem name='refreshAction' action='refreshAction'/><toolitem name='deleteAction' action='deleteAction'/></toolbar></ui>");
		this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
		this.toolbar1.Name = "toolbar1";
		this.toolbar1.ShowArrow = false;
		this.vbox1.Add (this.toolbar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.toolbar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.treeView = new global::Gtk.TreeView ();
		this.treeView.CanFocus = true;
		this.treeView.Name = "treeView";
		this.GtkScrolledWindow.Add (this.treeView);
		this.vbox1.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
		w4.Position = 1;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.nameInput = new global::Gtk.Entry ();
		this.nameInput.CanFocus = true;
		this.nameInput.Name = "nameInput";
		this.nameInput.IsEditable = true;
		this.nameInput.InvisibleChar = '•';
		this.hbox1.Add (this.nameInput);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.nameInput]));
		w5.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.AddButton = new global::Gtk.Button ();
		this.AddButton.CanFocus = true;
		this.AddButton.Name = "AddButton";
		this.AddButton.UseUnderline = true;
		this.AddButton.Label = global::Mono.Unix.Catalog.GetString ("Añadir");
		this.hbox1.Add (this.AddButton);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.AddButton]));
		w6.Position = 2;
		w6.Expand = false;
		w6.Fill = false;
		this.vbox1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
		w7.Position = 2;
		w7.Expand = false;
		w7.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 400;
		this.DefaultHeight = 300;
		this.nameInput.Hide ();
		this.AddButton.Hide ();
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.addAction.Activated += new global::System.EventHandler (this.OnAddActionActivated);
		this.refreshAction.Activated += new global::System.EventHandler (this.OnRefreshActionActivated);
		this.deleteAction.Activated += new global::System.EventHandler (this.OnDeleteActionActivated);
		this.AddButton.Clicked += new global::System.EventHandler (this.OnAddButtonClicked);
	}
}
