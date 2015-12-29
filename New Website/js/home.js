var slider = new Slider({
    slidesCount: 2,
    slideDelay: 500,
    slideTime: 6000
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
    
    setScrollerDelay(500);
    attachScrollingEvent('nav', 'remove-color', 25);
    
    slider.startSliding();
});