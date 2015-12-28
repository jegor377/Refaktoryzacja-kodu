var slider = new Slider({
    slidesCount: 2,
    slideDelay: 500,
    slideTime: 6000
});

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
    setCodedValues([
        {
            where: '#about-content > p', 
            what: 'age', 
            toWhat: new Date().getFullYear() - 2001
        },
        {
            where: '#about-content > p', 
            what: 'p_start', 
            toWhat: new Date().getFullYear() - 2010
        },
        {
            where: ['footer > h4', 
                    'footer > h5'], 
            what: 'date', 
            toWhat: new Date().getFullYear() == 2015 ? 2015 : "2015 - " + new Date().getFullYear()
        }
    ]);
    
    attachScrollingEvent();
    
    slider.startSliding();
});

function attachScrollingEvent()
{
    $(window).bind('scroll', function(){
        if($(window).scrollTop() > 25 && $('nav').hasClass('remove-color'))
        {
            $('nav').removeClass('remove-color');
        }
        else if($(window).scrollTop() <= 25)
        {
            $('nav').addClass('remove-color');
        }
    });
}