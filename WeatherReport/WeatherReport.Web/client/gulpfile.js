'use strict';

var gulp = require('gulp');
var plugins = require('gulp-load-plugins')();
var fs = require('fs');
var cheerio = require('cheerio');
var merge = require('merge-stream');

var config = {
  index: 'dist/index.html',
  manifestDefaults: {
    manifestFile: '../asset_manifest.json',
    includeRelativePath: true,
    pathSeparator: '/',
    log: false,
    pathPrepend: 'client/'
  }
};

function createManifest(files, bundle, bundleType) {
  return gulp.src(files, {
      cwd: '..'
    })
    .pipe(plugins.plumber())
    .pipe(plugins.assetManifest(Object.assign({
      bundleName: bundle + ':' + bundleType
    }, config.manifestDefaults)));
}

gulp.task('manifest', function () {
  let scripts = [],
    styles = [];
  if (fs.existsSync(config.index)) {
    let contents = fs.readFileSync(config.index, 'utf8');
    let $ = cheerio.load(contents);

    $('script').each(function (i, elem) {
      let script = $(this).attr('src');
      scripts.push(script);
    });

    $('link').each(function (i, elem) {
      let style = $(this).attr('href');
      styles.push(style);
    });
  }

  return merge(createManifest(styles, 'app.css', 'src'),
    createManifest(scripts, 'app.js', 'src'));
});
