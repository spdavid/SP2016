
var gulp = require('gulp')
var spsave = require('gulp-spsave')
var watch = require('gulp-watch')
var changed = require('gulp-cached');



var coreOptions = {
    siteUrl: 'https://zalo.sharepoint.com/sites/devsearch',
    notification: true,
    folder: "_catalogs/masterpage/Display Templates/",
    flatten: false

};
var creds = {
    username: 'david@zalosolutions.com',
    password: 'some password'
};


gulp.task('spdefault', function() {
    return gulp.src('src/*/*.*')
        .pipe(changed('src/*.*'))
        .pipe(spsave(coreOptions, creds));     
});


gulp.task('default', function() {
        gulp.watch(['./src/*/*.*'], ['spdefault']);
});

