import Vue from 'vue'
import Router from 'vue-router'

import Home from './pages/Home'
import Login from './pages/Login'
import Library from './pages/Library'
import Authors from './pages/Authors'

Vue.use(Router);

export default new Router({
    mode: 'history',
    routes: [
        {
            path: '/',
            name: 'home',
            component: Home,
        },
        {
            path: '/login',
            name: 'login',
            component: Login,
        },
        {
            path: '/library',
            name: 'library',
            component: Library,
        },
        {
            path: '/authors',
            name: 'authors',
            component: Authors,
        }
    ]

})

