
function setCurrentMenuItem(item, subitem) {
    $(".navigation li").each(function () {
        $(this).removeClass("active");
        if ($(this).children.length > 0) {
            $(this.children).each(function () {
                $(this).removeClass("current");
            });
        }
    });
    $("#" + item).addClass("active");
    $("#" + item + " > a").addClass("expand subOpened");
    $("#" + item + " > a").attr("id", "current");
    $("#" + subitem).addClass("current");
}