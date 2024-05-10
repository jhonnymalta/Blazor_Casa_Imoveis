window.ShowToastr = (type, message) => {    
    if (type === "success") {
        toastr.success(message, "successfully", { timeOut: 1000 })
    }
    else if (type === "error") {
        toastr.error(message, "failed", {timeOut: 1000})
    }
}