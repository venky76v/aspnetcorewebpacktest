const path = require('path');
var webpack = require("webpack");
var fs = require("fs");
const prod = process.argv.indexOf('-p') !== -1;

module.exports = {
    entry: {
        // Output a "home.js" file from the "home-page.ts" file
        home: './Scripts/home/home-page.ts',
        // Output a "contact.js" file from the "contact-page.ts" file
        contact: './Scripts/contact/contact-page.ts'
    },

    resolve: {
        extensions: [".ts"]
    },

    module: {
        rules: [
            {
                test: /\.tsx?$/,
                loader: 'ts-loader',
                exclude: /node_modules/,
            }
        ]
    },

    plugins: [
        // Use a plugin which will move all common code into a "vendor" file
        new webpack.optimize.CommonsChunkPlugin({
            name: 'Vendor'
        }),
        // Output stats.json
        function () {
            // When webpack has finished
            this.plugin("done", function (stats) {
                // try and find a "Webpack" folder
                var wpPath = path.join(__dirname, "Webpack");
                if (fs.existsSync(wpPath) === false) {
                    // If it doesn't exist, create it
                    fs.mkdirSync(wpPath);
                }
                // write the stats.json file to the Webpack folder
                fs.writeFileSync(
                    path.join(wpPath, "stats.json"),
                    JSON.stringify(stats.toJson()));
            });
        },
    ],

    output: {
        // The Format for the outputted files
        filename: (prod) ? "[name].[chunkhash].js" : "[name].js",
        // Put the file in "wwwroot/js/" directory
        path: path.resolve(__dirname, 'wwwroot/js/')
    }
}