import { createStore } from "vuex" 
import router from "../router/index"

const store = createStore({
    state:{
        searchButtonLoading: false,
        home: {title: "store name"},
        name: "Vue",
        addReview: {
            name:'',
            email:'',
            message:''
        },
        seachResults:[],
        hotel: {},
        user: {
            loggedIn: false,
        },
        bookingDetails: {
            hotelId: '',
            rooms: [
                {
                    type: '1',
                    nrOfRooms: ''
                },
                {
                    type: '2',
                    nrOfRooms: ''
                },
                {
                    type: '3',
                    nrOfRooms: ''
                }
            ],
            serviceType: '',
            extraBed: ''

        }
   },
   mutations:{
        setEmail(store, value){
            store.addReview.email = value
        },
        setMessage(store, value){
            store.addReview.message = value
        },
        setHotelSeachResultsList(store, value){
            store.seachResults = value;
            store.searchButtonLoading = false;
        },
        setHotel(store, value){
            store.hotel = value;
        }
   },
   actions:{
        async searchHotels({commit}, searchString){
            var response = await fetch('https://localhost:44356/api/Search/GetHotelByName?input=' + searchString); // Default is GET
            var result = await response.json();
            console.log(searchString, result)
            commit('setHotelSeachResultsList', result);
            if(result){
                router.push({name: 'result'})
            }
        },
        async getHotelById({commit}, hotelId){
            var response = await fetch('https://localhost:44356/api/Hotel/GetById/' + hotelId); // Default is GET
            var result = await response.json();
            commit('setHotel', result);
        },
        async setHotel({commit}, hotel){
            console.log("set hotel action")
            console.log(hotel)
            commit('setHotel', hotel)
        }
   }
})

export default store