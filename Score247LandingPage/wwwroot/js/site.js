// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(function () {
    "use strict";

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

    ////===== close navbar-collapse when a  clicked

    //$(".navbar-nav a").on('click', function () {
    //    $(".navbar-collapse").removeClass("show");
    //});

    ////===== Mobile Menu

    //$(".navbar-toggler").on('click', function () {
    //    $(this).toggleClass("active");
    //});

    //$(".navbar-nav a").on('click', function () {
    //    $(".navbar-toggler").removeClass('active');
    //});

    ////===== Sidebar

    //$('[href="#side-menu-right"], .overlay-right').on('click', function (event) {
    //    $('.sidebar-right, .overlay-right').addClass('open');
    //});

    //$('[href="#close"], .overlay-right').on('click', function (event) {
    //    $('.sidebar-right, .overlay-right').removeClass('open');
    //});

    ////===== Isotope Project 3

    //$('.container').imagesLoaded(function () {
    //    var $grid = $('.grid').isotope({
    //        // options
    //        transitionDuration: '1s'
    //    });

    //    // filter items on button click
    //    $('.portfolio-menu ul').on('click', 'li', function () {
    //        var filterValue = $(this).attr('data-filter');
    //        $grid.isotope({
    //            filter: filterValue
    //        });
    //    });

    //    //for menu active class
    //    $('.portfolio-menu ul li').on('click', function (event) {
    //        $(this).siblings('.active').removeClass('active');
    //        $(this).addClass('active');
    //        event.preventDefault();
    //    });
    //});

    ////  Magnific Popup

    //$('.image-popup').magnificPopup({
    //    type: 'image',
    //    gallery: {
    //        enabled: true
    //    }
    //});

    ////====== Magnific Popup

    //$('.video-popup').magnificPopup({
    //    type: 'iframe'
    //    // other options
    //});

    ////===== Slick

    //$('.testimonial-active').slick({
    //    infinite: true,
    //    slidesToShow: 3,
    //    slidesToScroll: 1,
    //    speed: 800,
    //    arrows: false,
    //    dots: true,
    //    autoplay: true,
    //    autoplaySpeed: 5000,
    //    responsive: [
    //        {
    //            breakpoint: 1200,
    //            settings: {
    //                slidesToShow: 3,
    //            }
    //        },
    //        {
    //            breakpoint: 992,
    //            settings: {
    //                slidesToShow: 2,
    //            }
    //        },
    //        {
    //            breakpoint: 768,
    //            settings: {
    //                slidesToShow: 1,
    //            }
    //        },
    //        {
    //            breakpoint: 576,
    //            settings: {
    //                slidesToShow: 1,
    //                arrows: false,
    //            }
    //        }
    //    ]
    //});

    ////===== Slick

    //$('.testimonial-active-2').slick({
    //    infinite: true,
    //    slidesToShow: 2,
    //    slidesToScroll: 1,
    //    speed: 800,
    //    arrows: false,
    //    dots: true,
    //    autoplay: true,
    //    autoplaySpeed: 5000,
    //    responsive: [
    //        {
    //            breakpoint: 1200,
    //            settings: {
    //                slidesToShow: 2,
    //            }
    //        },
    //        {
    //            breakpoint: 992,
    //            settings: {
    //                slidesToShow: 1,
    //            }
    //        },
    //        {
    //            breakpoint: 768,
    //            settings: {
    //                slidesToShow: 1,
    //            }
    //        },
    //        {
    //            breakpoint: 576,
    //            settings: {
    //                slidesToShow: 1,
    //                arrows: false,
    //            }
    //        }
    //    ]
    //});

    ////===== Slick

    //$('.client-active').slick({
    //    infinite: true,
    //    slidesToShow: 6,
    //    slidesToScroll: 1,
    //    speed: 800,
    //    arrows: false,
    //    dots: false,
    //    autoplay: true,
    //    responsive: [
    //        {
    //            breakpoint: 1200,
    //            settings: {
    //                slidesToShow: 6,
    //            }
    //        },
    //        {
    //            breakpoint: 992,
    //            settings: {
    //                slidesToShow: 5,
    //            }
    //        },
    //        {
    //            breakpoint: 768,
    //            settings: {
    //                slidesToShow: 3,
    //            }
    //        },
    //        {
    //            breakpoint: 576,
    //            settings: {
    //                slidesToShow: 2,
    //                arrows: false,
    //            }
    //        }
    //    ]
    //});

    ////===== Slick

    //$('.testimonial-active-4').slick({
    //    infinite: true,
    //    slidesToShow: 2,
    //    slidesToScroll: 1,
    //    speed: 800,
    //    arrows: false,
    //    dots: true,
    //    autoplay: true,
    //    autoplaySpeed: 5000,
    //    responsive: [
    //        {
    //            breakpoint: 1200,
    //            settings: {
    //                slidesToShow: 2,
    //            }
    //        },
    //        {
    //            breakpoint: 992,
    //            settings: {
    //                slidesToShow: 2,
    //            }
    //        },
    //        {
    //            breakpoint: 768,
    //            settings: {
    //                slidesToShow: 1,
    //            }
    //        },
    //        {
    //            breakpoint: 576,
    //            settings: {
    //                slidesToShow: 1,
    //                arrows: false,
    //            }
    //        }
    //    ]
    //});

    ////=====  AOS

    //new WOW().init();

    ////=====
});