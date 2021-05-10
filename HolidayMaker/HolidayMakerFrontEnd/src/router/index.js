import { createRouter, createWebHistory } from 'vue-router'
import HelloWorld from '/src/components/HelloWorld.vue'

import HotelView from '/src/components/pages/HotelView.vue'
import RoomInfo from '/src/components/RoomInfo.vue'

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
    },
    {
        path: '/hotels/:id/rooms',
        name: 'hotels',
        component: RoomInfo,
    }
]
const router = createRouter({
    history: createWebHistory(),
    routes,
})
export default router