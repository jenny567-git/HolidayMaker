import { createRouter, createWebHistory } from 'vue-router'
import HelloWorld from '/src/components/HelloWorld.vue'
import Info from '../components/pages/HotelViewComponents/Info.vue'
import HotelView from '/src/components/pages/HotelView.vue'
import RoomInfo from '/src/components/RoomInfo.vue'
import Photos from '/src/components/Photos.vue'

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
        }]
    },
    {
        path: '/hotels/:id/rooms',
        name: 'hotels',
        component: RoomInfo,
    },
    {
        path: '/hotels/:id/Photos',
        name: 'photos',
        component: Photos,
    }
]
const router = createRouter({
    history: createWebHistory(),
    routes,
})
export default router