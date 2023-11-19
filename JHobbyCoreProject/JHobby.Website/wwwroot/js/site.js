// Featured Venues Slider
function Jhobby_featured_venues_slider() {
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
function Jhobby_counter_up() {


	if ($('.coach-count .counter-up').length > 0) {
		$('.coach-count .counter-up').counterUp({
			delay: 15,
			time: 1500
		});
	}
}
