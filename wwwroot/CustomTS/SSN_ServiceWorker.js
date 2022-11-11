// 11/10/2022 03:12 pm - SSN - Added
// https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorker
console.log('%c ' + 'SSN_ServiceWork-20221110-1524', 'color:yellow;font-size:14pt;');
console.log('%c ' + 'SSN_ServiceWork-20221110-1524', 'color:yellow;font-size:14pt;');
function setup() {
    console.log('%c ' + 'SSN_ServiceWork-20221110-1524', 'color:yellow;font-size:14pt;');
    console.log('navigator: ');
    console.dir(navigator);
    if ("serviceWorker" in navigator || true) {
        navigator.serviceWorker
            .register("/customTS/ssn-service-worker-101.js", {
            scope: "./",
        })
            .then(function (registration) {
            var serviceWorker;
            if (registration.installing) {
                serviceWorker = registration.installing;
                console.log('%c ' + 'SSN_ServiceWork-20221110-1530-A  installing', 'color:yellow;font-size:14pt;');
            }
            else if (registration.waiting) {
                serviceWorker = registration.waiting;
                console.log('%c ' + 'SSN_ServiceWork-20221110-1530-B  waiting', 'color:yellow;font-size:14pt;');
            }
            else if (registration.active) {
                serviceWorker = registration.active;
                console.log('%c ' + 'SSN_ServiceWork-20221110-1530-C  Active', 'color:yellow;font-size:14pt;');
            }
            if (serviceWorker) {
                // logState(serviceWorker.state);
                serviceWorker.addEventListener("statechange", function (e) {
                    // logState(e.target.state);
                    console.log('%c ' + 'SSN_ServiceWork-20221110-1530-D  StateChange', 'color:yellow;font-size:14pt;');
                    console.log('%c ' + 'e:', 'color:yellow;font-size:14pt;');
                    console.dir(e);
                });
            }
        })["catch"](function (error) {
            // Something went wrong during registration. The service-worker.js file
            // might be unavailable or contain a syntax error.
            console.log('%c ' + 'SSN_ServiceWork-20221110-1530-Error  ', 'color:Red;font-size:14pt;');
            console.log('%c ' + 'SSN_ServiceWork-20221110-1530-Error  ', 'color:Red;font-size:14pt;');
            console.log('%c ' + 'SSN_ServiceWork-20221110-1530-Error  ', 'color:Red;font-size:14pt;');
            console.dir(error);
        });
    }
    else {
        // The current browser doesn't support service workers.
        // Perhaps it is too old or we are not in a Secure Context.
        console.log('%c ' + 'SSN_ServiceWork-20221110-1530-Does not support ServiceWorker', 'color:Red;font-size:14pt;');
    }
}
setup();
