function Slider(attributes)
{
    this.slidesName = attributes != null ? (attributes.slidesName != undefined ? attributes.slidesName : "#slide") : "#slide";
    this.slidesCount = attributes != null ? (attributes.slidesCount != undefined ? attributes.slidesCount : 1) : 1;
    this.startPoint = attributes != null ? (attributes.startPoint != undefined ? attributes.startPoint : 1) : 1;
    this.slideDelay = attributes != null ? (attributes.slideDelay != undefined ? attributes.slideDelay : 1000) : 1000;
    this.sliderWindow = attributes != null ? (attributes.sliderWindow != undefined ? attributes.sliderWindow : "#slider-window") : "#slider-window";
    this.sliderDots = attributes != null ? (attributes.sliderDots != undefined ? attributes.sliderDots : "#slider-dots") : "#slider-dots";
    
    this.acutalSlide = this.startPoint <= this.slidesCount ? this.startPoint : this.error();
    
    this.startSliding = function()
    {
        this.createDots();
        this.bindDotsToSlides();
        this.hideEveryOtherSlides();
    }
    
    this.createDots = function()
    {
        result = "";
        
        for(a=1; a<=this.slidesCount; a++) {
            result += '<li><a id="dot-' + this.removeIDorClass(this.slidesName) + a + 
                '" class="dot"><i class="fa fa-circle"></i></a></li>';
        }
        
        $(this.sliderDots + " > ul").html(result+'<div class="slider-end"></div>');
    }
    
    this.bindDotsToSlides = function()
    {
        for(a=1; a<=this.slidesCount; a++) {
            $("#dot-"+this.removeIDorClass(this.slidesName)+a).bind('click', function(){
                alert("test");
            });
        }
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
            $(this.slidesName+this.acutalSlide).hide();
            $(this.slidesName+nextSlide).show();
            this.acutalSlide = nextSlide;
        }
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