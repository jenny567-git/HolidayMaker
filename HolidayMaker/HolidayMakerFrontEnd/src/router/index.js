import { createRouter, createWebHistory } from "vue-router";
import HelloWorld from "/src/components/HelloWorld.vue";
import Info from "../components/pages/HotelViewComponents/Info.vue";
import HotelView from "/src/components/pages/HotelView.vue";
import RoomInfo from "../components/pages/HotelViewComponents/RoomInfo.vue";
import Photos from "../components/pages/HotelViewComponents/Photos.vue";
import Reviews from "../components/pages/HotelViewComponents/Reviews.vue";
import SearchResult from "../components/pages/SearchResult.vue";
import AddReview from "../components/pages/HotelViewComponents/ReviewComponents/AddReview.vue";
import OrderCompletedView from "../components/pages/OrderCompletedView.vue";
import CheckoutView from "../components/pages/CheckoutView.vue";
import Body from "../components/pages/MainPage/Body.vue";
import { registerRuntimeCompiler } from "@vue/runtime-core";
import Home from "/src/components/pages/Home.vue";
import ReservationDetails from "/src/components/pages/ReservationDetails.vue";
import ProfileMain from "../components/pages/CustomerProfile/ProfileMain.vue";

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/Profile",
    name: "Profile",
    component: ProfileMain,
    // children: [
    //   {
    //     path: "Home",
    //     component: Profile,
    //   },
    //   {
    //     path: "Booking",
    //     name: "booking",
    //     component: Booking,
    //   },
    //   {
    //     path: "Favorite",
    //     name: "favorite",
    //     component: SavedHotels,
    //   },
    //   {
    //     path: "ProfileSetting",
    //     name: "profileSetting",
    //     component: ProfileSettings,
    //   },
    // ],
  },
  {
    path: "/result",
    name: "result",
    component: SearchResult,
  },
  {
    path: "/addReview",
    name: "addReview",
    component: AddReview,
  },
  {
    path: "/hotels/:id",
    name: "hotels",
    component: HotelView,
    children: [
      {
        path: "",
        component: Info,
      },
      {
        path: "rooms",
        name: "hotels",
        component: RoomInfo,
      },
      {
        path: "Photos",
        name: "photos",
        component: Photos,
      },
      {
        path: "Reviews",
        name: "reviews",
        component: Reviews,
      },
    ],
  },
  {
    path: "/orderCompleted",
    name: "OrderCompleted",
    component: OrderCompletedView,
  },
  {
    path: "/checkout",
    name: "Checkout",
    component: CheckoutView,
  },
  {
    path: "/reservationdetails/:id",
    name: "reservationdetails",
    component: ReservationDetails,
  },
];
const router = createRouter({
  history: createWebHistory(),
  routes,
});
export default router;
