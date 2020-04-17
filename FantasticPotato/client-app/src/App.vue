<template>
  <div id="app">
    <Home></Home>
    <Login></Login>
  </div>
</template>

<script>

import Home from  './pages/Home'
import Login from  './pages/Login'

export default {
  name: 'App',
  components: {
    Home,
    Login
  }
}
</script>

<style>
</style>
