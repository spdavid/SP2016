//https://api.github.com/search/repositories?q=tetris+language


import { Utilities as utils } from 'Utilities'

//import ultils2 from 'Utilities';


    utils.GetJson("https://api.github.com/search/repositories?q=tetris+language", (data) => {
        console.log(data);

    });


