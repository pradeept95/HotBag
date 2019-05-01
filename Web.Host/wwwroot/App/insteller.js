(function () {
    var renderVueFunction = function(modules){
        var vm = new Vue({
            el: '#installer',
            data: function () {
                return {
                    isRestartIsRequired: false,
                    appname: 'HotBag',
                    allmodules: modules,
                    
                }
            },
            created: function () {

            },
            methods: {
                moduleSelectChanged: function (index) {
                    this.allmodules[index].isInstalled = !this.allmodules[index].isInstalled;
                    console.log(this.allmodules);
                },
                installModules: function () {
                    $.ajax({
                        type: "POST",
                        url: "/Home/UpdateInstall",
                        //contentType: "application/json",
                        //accepts: "application/json",
                        data: { model: { modules : this.allmodules }}
                    })
                    .done(
                        function (result) {
                            if (result && result.success) { 
                                swal({
                                    title: "Success",
                                    text: result.message + ", You have to Restart your application in order to reflect the chang in module insatllation.",
                                    icon: "success",
                                    buttons: true,
                                    dangerMode: true,
                                })
                                    .then((restart) => {
                                        if (restart) {
                                            vm.restartApplication()
                                        } else {
                                            vm.isRestartIsRequired = true;
                                            swal("Application will restart letter.", { icon: "success" });
                                        }
                                    });
                            }
                            else { 
                                swal("Ooooh, Got Error!", result.message, "error", { icon: "error" });
                            }
                        });
                },
                restartApplication : function () {
                    $.ajax({
                        type: "GET",
                        url: "/Home/RestartApplication" 
                    })
                    .done(
                    function (result) {
                        if (result && result.success) { 
                            vm.isRestartIsRequired = false;
                            swal("Good job!", result.message, "success", { icon: "success"});
                        }
                        else {
                            swal("Ooooh, Got Error!", result.message, "error", { icon: "error" });
                        }
                    });
                }
            },
        });
    }

    $.ajax({
        type: "GET",
        url: "/Home/GetAllModule"
    })
    .done(
        function (result) {
            if (result && result.data) {
                renderVueFunction(result.data)
            }
            else
            {
                renderVueFunction([])
            } 
        });
})();