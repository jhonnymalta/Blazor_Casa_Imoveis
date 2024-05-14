window.ShowToastr = (type, message) => {    
    if (type === "success") {
        toastr.success(message, "successfully", { timeOut: 1000 })
    }
    else if (type === "error") {
        toastr.error(message, "failed", {timeOut: 1000})
    }
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire("Success Notification",message, "success")
    }
    else if (type === "error") {
        Swal.fire("Error Notification", message, "error")
    }
}