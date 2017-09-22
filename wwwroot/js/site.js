// Write your Javascript code.
$(document).ready(function(){
  $('#UpdateTimeModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var lapId = button.data('lapsequence') // Parse lap Id from link attribute
    var position = button.data('lapposition') // Parse start or finish from link attribute

    var modal = $(this)
    modal.find('.modal-title').text('Update actual ' + position + ' time for lap ' + lapId) // Generate infformative modal header
    modal.find('.modal-content').attr('action', '/UpdateTimes/' + lapId + '/' + position) // Generate path for form action
  })  
})