var spsave = require('gulp-spsave');
var gulp = require('gulp');
var watch = require('gulp-watch');
var prompt = require('gulp-prompt');
var ts = require('gulp-typescript');


var tsProject = ts.createProject('./tsconfig.json');


var coreOptions = {
    siteUrl: 'https://zalodev.sharepoint.com/sites/od1',
    notification: true,
    folder: "Code",
    flatten: false

};

var creds = {
    username: 'david@zalodev.com',
    password: 'Folkissp16'
};


gulp.task("copyToSharePoint", function () {
    return gulp.src("./src/code/*.*")
        .pipe(spsave(coreOptions, creds));
});

gulp.task('compile-ts', function() {
    return tsProject.src() // instead of gulp.src(...) 
               .pipe(tsProject())
               .js.pipe(gulp.dest("src/code"));
             
});

gulp.task("default", function () {
   
    gulp.watch(['./tsSource/**/*.ts'], ['compile-ts']);
    gulp.watch(["./src/Code/*.*"], ["copyToSharePoint"]);
});