function Slider(attributes)
{
    this.slidesName = attributes != null ? (attributes.slidesName != undefined ? attributes.slidesName : "#slide") : "#slide";
    this.slidesCount = attributes != null ? (attributes.slidesCount != undefined ? attributes.slidesCount : 1) : 1;
    this.startPoint = attributes != null ? (attributes.startPoint != undefined ? attributes.startPoint : 1) : 1;
    this.slideDelay = attributes != null ? (attributes.slideDelay != undefined ? attributes.slideDelay : 1000) : 1000;
    this.sliderWindow = attributes != null ? (attributes.sliderWindow != undefined ? attributes.sliderWindow : "#slider-window") : "#slider-window";
    this.sliderDots = attributes != null ? (attributes.sliderDots != undefined ? attributes.sliderDots : "#slider-dots") : "#slider-dots";
    this.referenceName = attributes != null ? (attributes.referenceName != undefined ? attributes.referenceName : "slider") : "slider";
    this.slideTime = attributes != null ? (attributes.slideTime != undefined ? attributes.slideTime : 1000) : 1000;
    
    this.acutalSlide = this.startPoint <= this.slidesCount ? this.startPoint : this.error();
    
    this.startSliding = function()
    {
        this.createDots();
        this.hideEveryOtherSlides();
        setInterval(this.startSlidingSlider, this.slideTime, this);
    }
    
    this.createDots = function()
    {
        result = "";
        
        for(a=1; a<=this.slidesCount; a++) {
            result += '<li><a id="dot-' + this.removeIDorClass(this.slidesName) + a + 
                '" onclick="' + this.referenceName + '.setSlide(' + a + ')" class="dot"><i class="fa fa-circle"></i></a></li>';
        }

        $(this.sliderDots + " > ul").html(result+'<div class="slider-end"></div>');
        this.setDotOn(this.acutalSlide);
    }
    
    this.hideEveryOtherSlides = function()
    {
        for(a=1; a<=this.slidesCount; a++) {
            if(a!=this.startPoint) $(this.slidesName + a).hide();
        }
    }
    
    this.setSlide = function(nextSlide)
    {
        if(nextSlide >= 1 && nextSlide <= this.slidesCount) {
            this.setDotOff(this.acutalSlide);
            $(this.slidesName+this.acutalSlide).hide(this.slideDelay);
            $(this.slidesName+nextSlide).show(this.slideDelay);
            this.acutalSlide = nextSlide;
            this.setDotOn(this.acutalSlide);
        }
    }
    
    this.setDotOn = function(dotNumber)
    {
        if(dotNumber >= 1 && dotNumber <= this.slidesCount) {
            $('#dot-' + this.removeIDorClass(this.slidesName) + dotNumber).css('opacity', '0.67')
        }
    }
    
    this.setDotOff = function(dotNumber)
    {
        if(dotNumber >= 1 && dotNumber <= this.slidesCount) {
            $('#dot-' + this.removeIDorClass(this.slidesName) + dotNumber).css('opacity', '0.4')
        }
    }
    
    this.startSlidingSlider = function(object)
    {
        object.setSlide(object.acutalSlide+1 <= object.slidesCount ? object.acutalSlide+1 : 1);
    }
    
    this.error = function()
    {
        alert("startPoint is greater than slidesCount");
        return this.startPoint;
    }
    
    this.removeIDorClass = function(string)
    {
        return (string.charAt(0)=='#' || string.charAt(0)=='.' ? 
                                       string.substr(1, string.length-1) : string);
    }
}