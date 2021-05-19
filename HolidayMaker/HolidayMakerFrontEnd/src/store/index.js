import { createStore } from "vuex" 

const store = createStore({
    state:{
        home: {title: "store name"},
        name: "Vue",
        addReview: {
            name:'',
            email:'',
            message:''
        },
        seachResults:[],
        hotels: {
            1:{
                name: 'Hotel 1',
                description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer dapibus lacus a diam rhoncus suscipit. Nulla facilisi. Maecenas non metus faucibus, feugiat lectus non, elementum urna. Morbi viverra gravida diam, et tincidunt felis laoreet vitae. Suspendisse vel metus non ex tempus tincidunt. Proin egestas sapien nisi, eu elementum est aliquet.'
            },
            2:{
                name: 'Hotel 2',
                description: 'In varius, nisi quis blandit porta, dolor tortor aliquam odio, eget consectetur lectus leo a massa. Proin dignissim dignissim porttitor. Praesent sed risus id diam dapibus consectetur. Vivamus sollicitudin urna ut tincidunt varius. Morbi congue malesuada erat id luctus. Nunc.'
            },
        },
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
        }
   },
   actions:{
        async searchHotels({commit}, searchString){
            var response = await fetch('https://localhost:44356/api/Search/GetHotelByName?input=' + searchString); // Default is GET
            var result = await response.json();
            
            commit('setHotelSeachResultsList', result);
        },
   }
})

export default store