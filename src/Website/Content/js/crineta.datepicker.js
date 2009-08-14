$(function() {
	$(".datepicker").datepicker({
	    onSelect: function(dateText) {
	        $(this).val($(this).val() + ' ' + $(this).attr("rel"));
	    }
	});
});
