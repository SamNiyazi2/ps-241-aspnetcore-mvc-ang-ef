
// 09/02/2020 02:34 pm - SSN - [20200902-1401] - [002] - M14-02 - Minifying your JavaScript

// Does not produce results. Fails on minify.


//Running minify...
//Completed minify.
//[15: 35: 59]'minify' errored after 26 ms
//[15: 35: 59]GulpUglifyError: unable to minify JavaScript
//Caused by: SyntaxError: Unexpected token: name «textMessage», expected: punc «; »
//File: C: \Sams_P\PS\aspnetcore - mvc - efcore - bootstrap - angular - web\hw_DutchTreat\ps - DutchTreat\wwwroot\js\index.js
//Line: 20
//Col: 12
//[15: 35: 59]'default' errored after 29 ms
//Process terminated with code 1.


var gulp = require('gulp');

var uglify = require("gulp-uglify");
var concat = require("gulp-concat");


//gulp.task('minify', function (done) {
  function minify () {

    console.log(' ');
    console.log('Running minify...');

    gulp.src("wwwroot/js/**/*.js")
        .pipe(uglify())
        .pipe(concat("dutchtreat.min.js"))
        .pipe(gulp.dest("wwwroot/dist_gulp"));

    console.log('Completed minify.');

    //done();
//});
}


//gulp.task('default', function (done) {

//    console.log('Running default task...');

//    // gulp.series('minify');
//    gulp.series(minify);

//    console.log('Completed default task.');

//    done();
//}
//);

exports.default = gulp.series(minify);
