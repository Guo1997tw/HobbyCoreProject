// Featured Venues Slider
function Jhobby_Ceatured_Venues_Slider() {
	if ($('.featured-venues-slider').length > 0) {
		$('.featured-venues-slider').owlCarousel({
			loop: true,
			margin: 24,
			nav: true,
			dots: false,
			autoplay: false,
			smartSpeed: 2000,
			navText: ["<i class='feather-chevron-left'></i>", "<i class='feather-chevron-right'></i>"],
			responsive: {
				0: {
					items: 1
				},
				500: {
					items: 1
				},
				768: {
					items: 2
				},
				1000: {
					items: 3
				}
			}
		})
	}
}

// JQuery CounterUp
function Jhobby_Counter_Up() {


	if ($('.coach-count .counter-up').length > 0) {
		$('.coach-count .counter-up').counterUp({
			delay: 15,
			time: 1500
		});
	}
}

//Fade in Scroll
function Jhobby_AosInit() {
	AOS.init({
		duration: 1200,
		once: true
	})
}

// Select Favourite
function Jhobby_Fav_Icon() {
	$('.fav-icon').on('click', function () {
		$(this).toggleClass('selected');
	});
}

// Featured Coache Slider
function Jhobby_Featured_Coache_Slider() {
	if ($('.featured-coache-slider').length > 0) {
		$('.featured-coache-slider').owlCarousel({
			loop: true,
			margin: 24,
			nav: true,
			dots: false,
			autoplay: false,
			smartSpeed: 2000,
			navText: ["<i class='feather-chevron-left'></i>", "<i class='feather-chevron-right'></i>"],
			responsive: {
				0: {
					items: 1
				},
				500: {
					items: 1
				},
				768: {
					items: 2
				},
				1000: {
					items: 4
				}
			}
		})
	}
}

//動畫集合用函式
function Animations() {
	Jhobby_Ceatured_Venues_Slider();
	Jhobby_Counter_Up();
	Jhobby_AosInit()
	Jhobby_Fav_Icon();
	Jhobby_Featured_Coache_Slider();
}
//掛Vue後，動畫要延遲1.5秒後渲染
function Jhobby_Animation() {
	setTimeout(Animations, 1500)
}