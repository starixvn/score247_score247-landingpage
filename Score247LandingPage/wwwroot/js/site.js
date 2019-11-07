// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(function () {
    "use strict";

    $('a.page-scroll[href*="#"]:not([href="#"])').on('click', function () {
        if (location.pathname.replace(/^\//, '') === this.pathname.replace(/^\//, '') && location.hostname === this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html, body').animate({
                    scrollTop: target.offset().top
                }, 1200, "easeInOutExpo");
                return false;
            }
        }
    });

    //===== Sticky

    $(window).on('scroll', function (event) {
        var scroll = $(window).scrollTop();
        if (scroll < 5) {
            $(".navbar-area").removeClass("sticky");
        } else {
            $(".navbar-area").addClass("sticky");
        }
    });

    ////===== Section Menu Active

    var scrollLink = $('.page-scroll');
    // Active link switching
    $(window).scroll(function () {
        var scrollbarLocation = $(this).scrollTop();

        scrollLink.each(function () {
            var sectionOffset = $(this.hash).offset().top - 40;

            if (sectionOffset <= scrollbarLocation) {
                $(this).parent().addClass('active');
                $(this).parent().siblings().removeClass('active');
            }
        });
    });

    // Banner carousel
    $("#banner-carousel").owlCarousel({
        autoplay: true,
        autoPlayTimeout: 6000,
        smartSpeed: 400,
        autoplayHoverPause: true,
        items: 1,
        loop: true
    });

    // Rating reviews
    $('.ratingreviews-carousel').slick({
        autoplay: true,
        autoplaySpeed: 5000,
        centerMode: true,
        centerPadding: '60px',
        slidesToShow: 3,
        responsive: [
            {
                breakpoint: 768,
                settings: {
                    centerMode: true,
                    centerPadding: '40px',
                    slidesToShow: 3
                }
            },
            {
                breakpoint: 480,
                settings: {
                    centerMode: true,
                    centerPadding: '40px',
                    slidesToShow: 1
                }
            }
        ]
    });

    $('.qa').each(function () {
        var tis = $(this),
            state = false,
            answer = tis.children('.anwser').slideDown(),
            fullAnswer = tis.children('.anwser-full').slideUp();
        tis.click(function () {
            state = !state;
            answer.slideToggle(state);
            fullAnswer.slideToggle(!state);
            tis.toggleClass('active', state);
        });
    });
});