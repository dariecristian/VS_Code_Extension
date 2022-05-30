using System.Linq;

namespace ExtGuid
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var docView = await VS.Documents.GetActiveDocumentViewAsync();
            var selection = docView?.TextView.Selection.SelectedSpans.FirstOrDefault();

            if(selection.HasValue)
            {
                var guid = Guid.NewGuid().ToString();
                docView.TextBuffer.Replace(selection.Value, guid);
            }
        }
    }
}
