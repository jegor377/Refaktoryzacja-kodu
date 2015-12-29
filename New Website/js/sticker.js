function attachScrollingEvent(HTMLObject, HTMLClass, windowScrollerPosition)
{
    $(window).bind('scroll', function(){
        if($(window).scrollTop() > windowScrollerPosition && $(HTMLObject).hasClass(HTMLClass))
        {
            $(HTMLObject).removeClass(HTMLClass);
        }
        else if($(window).scrollTop() <= windowScrollerPosition)
        {
            $(HTMLObject).addClass(HTMLClass);
        }
    });
}