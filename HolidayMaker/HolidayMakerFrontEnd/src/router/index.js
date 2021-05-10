import { createRouter, createWebHistory } from 'vue-router'
import HelloWorld from '/src/components/HelloWorld.vue'

import { registerRuntimeCompiler } from '@vue/runtime-core'

const routes = [
    {
        path: '/',
        name: 'Home',
        component: HelloWorld,
    },
]
const router = createRouter({
    history: createWebHistory(),
    routes,
})
export default router