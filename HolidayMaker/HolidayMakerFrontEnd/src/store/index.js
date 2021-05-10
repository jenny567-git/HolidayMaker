import { createStore } from "vuex" 

const store = createStore({
    state:{
        home: {title: "store name"},
        name: "Vue",
        array: {
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