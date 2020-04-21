<template>
    <div>
        <form class="login" @submit.prevent ="authorization">
            <h1>Sign in</h1>
            <label>Login or email</label>
            <input required v-model="form.login" type="text" placeholder="Name"/>
            <label>Password</label>
            <input required v-model="form.password" type="password" placeholder="Password"/>
            <hr/>
            <button type="submit">Войти</button>
            <p v-if="errorView">{{error}}</p>
        </form>
    </div>
</template>

<script>
    import myLoginRoutine from '../auth'
    export default {
        data(){
            return{
                form: {
                    login: "",
                    password: ""
                },
                error: "",
                errorView: false
            }
        },
        methods: {
            authorization(){
                myLoginRoutine(this.form).then(res => {
                    let errors = ['User not found by email', 'User not found', 'Password mismatch!'];
                    if(errors.includes(res.data)){
                        this.error = res.data;
                        this.errorView = true;
                    }
                    else {
                        this.$router.push('/')
                    }
                })
            }
        }
    }
</script>
<style>
    #app{
        margin-top: 60px;
    }
</style>
