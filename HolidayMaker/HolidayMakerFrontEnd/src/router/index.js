import { createRouter, createWebHistory } from 'vue-router'
import HelloWorld from '/src/components/HelloWorld.vue'
import Info from '../components/pages/HotelViewComponents/Info.vue'
import HotelView from '/src/components/pages/HotelView.vue'
import RoomInfo from '../components/pages/HotelViewComponents/RoomInfo.vue'
import Photos from '../components/pages/HotelViewComponents/Photos.vue'
import Reviews from '../components/pages/HotelViewComponents/Reviews.vue'

import { registerRuntimeCompiler } from '@vue/runtime-core'

const routes = [
    {
        path: '/',
        name: 'Home',
        component: HelloWorld,
    },
    {
        path: '/hotels/:id',
        name: 'hotels',
        component: HotelView,
        children: [{
            path: 'info',
            component: Info,
        },
        {
            path: 'rooms',
            name: 'hotels',
            component: RoomInfo,
        },
        {
            path: 'Photos',
            name: 'photos',
            component: Photos,
        },
        {
            path: 'Reviews',
            name: 'reviews',
            component: Reviews,
        }  
    ]
    }   
]
const router = createRouter({
    history: createWebHistory(),
    routes,
})
export default router