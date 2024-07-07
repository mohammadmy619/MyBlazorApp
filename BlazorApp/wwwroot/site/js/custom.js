window.ShowToastr = (type, message) => {
    if (type === 'success') {
        toastr.success(message, 'عملیات مورد نظر با موفقیت انجام شد');
    }

    if (type === 'error') {
        toastr.error(message, 'عملیات با شکست مواجه شد');
    }
}

window.ShowSwal = (type, message) => {
    if (type === 'success') {
        Swal.fire(
            'اعلان موفقیت !!!',
            message,
            'success'
        );
    }

    if (type === 'error') {
        Swal.fire(
            'اعلان خطا !!!',
            message,
            'error'
        );
    }
}

function showConfirmationModal() {
    $('#confirmationModal').modal('show');
}

function hideConfirmationModal() {
    $('#confirmationModal').modal('hide');
}