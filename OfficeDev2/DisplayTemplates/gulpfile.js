
var gulp = require('gulp')
var spsave = require('gulp-spsave')
var watch = require('gulp-watch')
var cached = require('gulp-cached');

var coreOptions = {
    siteUrl: 'https://zalo.sharepoint.com/sites/devsearch',
    notification: true,
    folder: "_catalogs/masterpage/Display Templates/",
    flatten: false

};
var creds = {
    username: 'sa@zalosolutions.com',
    password: 'Folkis'
};


gulp.task('spdefault', function() {
    // runs the spsave gulp command on only files the have 
    // changed in the cached files
    return gulp.src('src/*/*.*')
        .pipe(cached('spFiles'))
        .pipe(spsave(coreOptions, creds));     
});


gulp.task('default', function() {
    // create an initial in-memory cache of files
    gulp.src('src/*/*.*')
    .pipe(cached('spFiles'));
    
    // watch the src folder
    gulp.watch(['./src/*/*.*'], ['spdefault']);
});

gulp.task('uploadAll', function() {
    // runs the spsave gulp command on only files the have 
    // changed in the cached files
    return gulp.src('src/*/*.*')
        .pipe(spsave(coreOptions, creds));     
});

