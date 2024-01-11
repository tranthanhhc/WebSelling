function _init_slider(carousel) {
	$('#slider-nav a').bind('click', function() {
		var index = $(this).parent().find('a').index(this);
		carousel.scroll( index + 1);
		return false;
	});
};

function _active_slide(carousel, item, idx, state) {
	var index = idx-1;
	$('#slider-nav a').removeClass('active');
	$('#slider-nav a').eq(index).addClass('active');
};

function _init_more_products(carousel) {
	$('.more-nav .next').bind('click', function() {
		carousel.next();
		return false;
	});
	
	$('.more-nav .prev').bind('click', function() {
		carousel.prev();
		return false;
	});
};

$(document).ready(function() {
	$("#slider-holder ul").jcarousel({
		scroll: 1,
		auto: 6,
		wrap: 'both',
		initCallback: _init_slider,
		itemFirstInCallback: _active_slide,
		buttonNextHTML: null,
		buttonPrevHTML: null
	});
	
	$(".more-products-holder ul").jcarousel({
		scroll: 2,
		auto: 5,
		wrap: 'both',
		initCallback: _init_more_products,
		buttonNextHTML: null,
		buttonPrevHTML: null
	});
});

//$(document).ready(function () {
//	// Xử lý sự kiện click cho các liên kết trong thanh điều hướng
//	$('#navigation ul li a').click(function () {
//		// Gỡ bỏ gạch chân và background cho tất cả các liên kết
//		$('#navigation ul li a').removeClass('active');
//		// Thêm gạch chân và background cho liên kết được nhấn
//		$(this).addClass('active');
//	});
//});

$(document).ready(function () {
	// Xử lý sự kiện click cho các liên kết trong thanh điều hướng
	$('#navigation ul li a').click(function (e) {
		e.preventDefault();
		// Gỡ bỏ lớp active khỏi tất cả các liên kết
		$('#navigation ul li a').removeClass('active');
		// Thêm lớp active cho liên kết được nhấn
		$(this).addClass('active');
		var targetUrl = $(this).attr('href');
		// Thêm hình tròn chạy vào trang
		$('body').append('<div class="page-transition"></div>');
		// Chờ một khoảng thời gian nhất định trước khi chuyển trang
		setTimeout(function () {
			// Chuyển trang đến URL tương ứng
			window.location.href = targetUrl;
		}, 100); // Đặt thời gian chờ là 1 giây (1000ms)
	});
});


