/* 
* Dependencias s
*/ 
var gulp = require('gulp'), 
	jade = require('gulp-jade'),
	concat = require('gulp-concat'), 
	uglify = require('gulp-uglify'),
	browserify = require('gulp-browserify'),
	sass = require('gulp-sass'),
	connect = require('gulp-connect');

gulp.task('jade', function() {
	return gulp.src('src/views/**.jade')
		.pipe(jade())
		.pipe(gulp.dest('build/views'));		
});

gulp.task('jadeIndex', function() {
	return gulp.src('index.jade')
		.pipe(jade())
		.pipe(gulp.dest('build'));		
});

gulp.task('watch', function() {
	gulp.watch('src/js/**/*.js', ['concat']);
	gulp.watch('src/scripts/*.*', ['copy-folder']);
	gulp.watch('src/styles/*.*', ['copy-folder']);
	gulp.watch('src/views/*.*', ['copy-folder']);
	gulp.watch('index.jade', ['jadeIndex']);
	// gulp.watch('src/jades/*.jade', ['jade']);
});

gulp.task('copy-folder', function() {
	gulp.src('src/js/**/*')
		.pipe(gulp.dest('build/js'));
	gulp.src('src/scripts/**/*')
		.pipe(gulp.dest('build/scripts'));
	gulp.src('src/styles/**/*')
		.pipe(gulp.dest('build/styles'));
	gulp.src('src/views/**/*')
		.pipe(gulp.dest('build/views'));
	// gulp.src('index.jade')
	// 	.pipe(gulp.dest('build'));
});

gulp.task('concat', function() {
	return gulp.src('src/js/**/*.js')
		.pipe(concat('main.js'))
		.pipe(gulp.dest('build/js'))
})

// gulp.task('connect', connect.server({
// 	root: 'build',
// 	open: { browser: 'Google Chrome' }
// }));

gulp.task('webserver', function() {
  connect.server({
    livereload: true,
    root: "build"
  });
});

gulp.task('js', function() {
	return gulp.src('src/js/*.*')
		// .pipe(browserify({ debug: true }))
		// .pipe(uglify()) 
		.pipe(gulp.dest('build/js'));
});

gulp.task('sass', function() {
	return gulp.src('src/sass/main.scss')
		.pipe(sass({ sourceComments: 'map' }))
		.pipe(gulp.dest('build/css'));
})
/* 
* Configuración de las tareas 'demo' 
*/ 
gulp.task('demo', function () { 
	gulp.src('js/src/*.js') 
		.pipe(concat('compilacion.js')) 
		// .pipe(uglify()) 
		.pipe(gulp.dest('js/build/')) 
}); 

gulp.task('default', ['js', 'jade', 'jadeIndex', 'watch', 'webserver', 'concat']);
