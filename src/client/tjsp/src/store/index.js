import Vue from 'vue';
import Vuex from 'vuex';

import { dataService } from '../shared/data.service';
import { localStorageToken, localStorageUserInfo } from '../shared/constants';

import {
	GET_USERINFO,
	SET_USERINFO,
	DEL_USERINFO,
  } from './mutation-types';

  Vue.use(Vuex);


const state = () => ({
    userInfo: undefined,
    token: undefined,
  });
  

const mutations = {

    [GET_USERINFO](state) {

      if( localStorage.getItem(`${localStorageUserInfo}`) !== undefined ) {

        state.userInfo = JSON.parse( localStorage.getItem(`${localStorageUserInfo}`) );
        state.token = localStorage.getItem(`${localStorageToken}`);
      }

    },

    [SET_USERINFO](state, userInfo) {
        state.userInfo = userInfo.userData;
        state.token = userInfo.token;

        localStorage.setItem(`${localStorageToken}`, state.token);
        localStorage.setItem(`${localStorageUserInfo}`, JSON.stringify( state.userInfo ));
    },

    [DEL_USERINFO](state) {

        state.userInfo = undefined;
        state.token = undefined;
        localStorage.removeItem(`${localStorageToken}`);
        localStorage.removeItem(`${localStorageUserInfo}`);
    }
}


const actions = {

    async signIn({ commit }, payload) {
        const resultUserInfo = await dataService.signIn(payload);
        if( resultUserInfo !== null) {
            commit(SET_USERINFO, resultUserInfo);
        }
    },

    signOut({ commit }) {
        commit(DEL_USERINFO);
    },

    loadUserInfo({ commit }) {
        commit(GET_USERINFO);
    }
}


const getters = {
    // parameterized getters are not cached. so this is just a convenience to get the state.
    getUserInfo: state => state.userInfo,
    getToken: state => state.token,
    getExpirationDate: state => state.expirationDate
  };


export default new Vuex.Store({
    strict: true,
    state,
    mutations,
    actions,
    getters,
  });
  