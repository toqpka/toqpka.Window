using System;
using System.Windows;
using Editor.BL;

namespace toqpka.Word
{
    public class MainPres
    {
        private readonly IMainForm _view;
        private readonly IFileManager _manager;
        private readonly IMessageService _massServ;

        public MainPres(IMainForm view, IFileManager manager, IMessageService service)
        {
            _view = view;
            _manager = manager;
            _massServ = service;

            _view.ContentChanged += new EventHandler(_view_ContentChanged);
        }

        private void _view_ContentChanged(object sender, EventArgs e)
        {
            string content = _view.Content;
        }
    }
}
