import { createStore } from "vuex" 

const store = createStore({
    state:{
        home: {title: "store name"},
        name: "Vue",
        hotels: {
            1:{
                name: 'Hotel 1',
                description: 'Desc 1'
            },
            2:{
                name: 'Hotel 2',
                description: 'Desc 2'
            },
        },
        user: {
            loggedIn: false,
        }
   },
   mutations:{

   },
   actions:{
        
   }
})

export default store