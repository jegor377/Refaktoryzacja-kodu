$(function() {
    $('a[href*=#]:not([href=#])').click(function() {
        if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
            if (target.length) {
                $('html,body').animate({
                    scrollTop: target.offset().top
                }, 500);
                return false;
            }
        }
    });
});

$(function() {
    setAboutValues();
    setFooterValue();
    attachScrollingEvent();
});

function setAboutValues()
{
    var about = $('#about-content > p').html();
    about = about.replace("{{age}}", new Date().getFullYear() - 2001);
    about = about.replace("{{p_start}}", new Date().getFullYear() - 2010);
    $('#about-content > p').html(about);
}

function setFooterValue()
{
    var footer = $('footer > h5').html();
    footer = footer.replace("{{date}}", new Date().getFullYear() == 2015 ? 2015 : "2015 - " + new Date().getFullYear());
    $('footer > h5').html(footer);
}

function attachScrollingEvent()
{
    $(window).bind('scroll', function(){
        if($(window).scrollTop() > 25 && $('nav').hasClass('remove-color')) $('nav').removeClass('remove-color');
        else if($(window).scrollTop() <= 25) $('nav').addClass('remove-color');
    });
}

var slider = new Slider({
    slidesCount: 2,
    slideDelay: 500
});

slider.startSliding();