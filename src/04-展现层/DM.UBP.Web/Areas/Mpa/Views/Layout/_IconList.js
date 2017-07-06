//(function ()
//{
//    $(function ()
//    {
//        $(".iconpane").click(function ()
//        {
//            var cls = $(this).find("i").attr("class");
//            $("#ModuleInformationsForm").contents().find("#Iconic").attr("class", cls);
//            $("#ModuleInformationsForm").contents().find("#Icon").val(cls);
//            //$("#modalwindowicon").window("close");
//        });
//    });
//})();

(function ($)
{
    app.modals.IconListModal = function ()
    {
        var _modalManager;

        this.init = function (modalManager)
        {
            _modalManager = modalManager;
        };

        $(".iconpane").click(function ()
        {
            var cls = $(this).find("i").attr("class");
            _modalManager.setResult(cls);
            _modalManager.close();
        });
    };
})(jQuery);