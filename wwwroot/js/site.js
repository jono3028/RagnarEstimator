// Write your Javascript code.
$(document).ready(function(){
  $('#UpdateTimeModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var lapId = button.data('lapsequence')
    var position = button.data('lapposition')

    var modal = $(this)
    modal.find('.modal-title').text('Update actual ' + position + ' time for lap ' + lapId)
    // modal.find('.modal-body input').val(lapId)
    modal.find('.modal-content').attr('action', '/UpdateTimes/' + lapId + '/' + position)
  })  
})