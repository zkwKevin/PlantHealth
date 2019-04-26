var HtmlWebpackPlugin = require('html-webpack-plugin');
var webpack = require('webpack');

module.exports = {
    mode: 'development',
    resolve: {
        extensions: ['.js', '.jsx']
    },
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                loader: 'babel-loader'
            },
            {   test: /\.css$/, 
                loader: "style-loader!css-loader" 
            },
            { 
                test: /\.(png|jpg|gif|svg|eot|ttf|woff|woff2)$/,
                use: {
                    loader: 'url-loader',
                    options: {
                        limit: 100000,
                    },
                }
            },
            // {
            //     // Exposes jQuery for use outside Webpack build
            //     test: require.resolve('jquery'),
            //     use: [{
            //       loader: 'expose-loader',
            //       options: 'jQuery'
            //     },{
            //       loader: 'expose-loader',
            //       options: '$'
            //     }]
            // }
            
        ]
    },
    plugins: [
        new HtmlWebpackPlugin({
        template: './src/index.html'
    }),
        // new webpack.ProvidePlugin({
        //     $: 'jquery',
        //     jQuery: 'jquery'
        // })
    ],
    devServer: {
        historyApiFallback: true
    },
    externals: {
        // global app config object
        config: JSON.stringify({
            apiUrl: 'http://localhost:4000'
        })
    }
}