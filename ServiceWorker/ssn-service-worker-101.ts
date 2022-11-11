
// 11/10/2022 04:31 pm - SSN 
// https://gist.github.com/bryandh/c22a39f22395f155123b6b82fcd5f438

console.log('%c ' + 'ssn-service-worker-101.ts - 20221110-1638', 'color:yellow;font-size:10pt;');

class ServiceWorkerOne {


    public static run(): void {

        console.log('%c ' + 'ssn-service-worker-101.ts - 20221110-1638-B', 'color:yellow;font-size:10pt;');

        addEventListener('install', ServiceWorkerOne.onInstalled);
        addEventListener('fetch', ServiceWorkerOne.onFetched);
    }

    public static onInstalled = (event: any): void => {

        console.log('%c ' + 'ssn-service-worker-101.ts - 20221110-1638-C', 'color:yellow;font-size:10pt;');

        event.waitUntil(
            caches.open('v0.1').then((cache) => {
                return cache.addAll([
                    '/scripts/app-bundle.js',
                    '/scripts/vendor-bundle.js',
                    '/assets/images/logo.png',
                    '/assets/images/no-vessel-picture.jpg',
                    '/assets/styles/loader.css',
                    '/assets/scripts/fontawesome-pro/css/fa-svg-with-js.css',
                    '/assets/scripts/fontawesome-pro/js/fontawesome.min.js',
                    '/assets/scripts/fontawesome-pro/js/fa-light.min.js',
                    '/assets/scripts/fontawesome-pro/js/fa-regular.min.js',
                    '/assets/scripts/fontawesome-pro/js/fa-solid.min.js'
                ]);
            })
        );
    }

    public static onFetched = (event: any): void => {

        console.log('%c ' + 'ssn-service-worker-101.ts - 20221110-1639', 'color:yellow;font-size:10pt;');

        event.respondWith(
            caches.match(event.request).then((matchResponse) => {
                return matchResponse || fetch(event.request).then((fetchResponse) => {
                    return caches.open('v0.1').then((cache) => {
                        cache.put(event.request, fetchResponse.clone());
                        return fetchResponse;
                    });
                });
            })
        );
    }
}

ServiceWorkerOne.run();

console.log('%c ' + 'ssn-service-worker-101.ts - 20221110-1640 - Dont loading', 'color:yellow;font-size:10pt;');
