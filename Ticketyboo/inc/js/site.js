(function () {

    var $sidebarWrapperAndWrapper = $("#sidebarWrapper,#wrapper");
    var $icon = $("#sidebarToggle i.fa");
    var $sidebarNav = $(".sidebarNav");
    var $sidebarWrapper = $(".sidebarWrapper.navbar.navbar-inverse");
    var $main = $("#main");

    $("#sidebarToggle").on("click", function () {
        $sidebarWrapperAndWrapper.toggleClass("hide-sidebar");
        $sidebarNav.toggleClass("hide-sidebar");
        $sidebarWrapper.toggleClass("hide-sidebar");
        $main.toggleClass("hide-sidebar");

        if ($sidebarWrapperAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        } else {
            $icon.addClass("fa-angle-left");
            $icon.removeClass("fa-angle-right");


        }
    });
})();