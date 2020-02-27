import * as axios from 'axios';
// import { format } from 'date-fns';
// import { inputDateFormat } from './constants';
import { localStorageToken } from './constants';
import { API } from './config';

axios.defaults.headers.common['Content-Type'] = 'application/json'
axios.defaults.headers.common['Access-Control-Allow-Origin'] = `${API}`;
axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
// axios.defaults.headers.common['Authorization'] = `Bearer ${localStorage.getItem(localStorageToken)}`;

const signIn = async function(payload) {

    try {

      const response = await axios.post(`${API}/security/Authenticate`, payload);
      var userInfo = parseItem(response, 200);

      return userInfo;

    } catch (error) {
      console.error(error);
      return null;
    }

  };

  const getEntity = async function(payload) {

    try {
      var options = {
            headers: {
            'Authorization': `Bearer ${localStorage.getItem(localStorageToken)}`,
          }
      };

      const response = await axios.post(`${API}/graphql`, payload, options);
      var entityResult = parseItem(response, 200);

      return entityResult;

    } catch (error) {
      console.error(error);
      return null;
    }

  };

  const executeQuery = async function(payload) {

    try {

      var options = {
            headers: {
            'Authorization': `Bearer ${localStorage.getItem(localStorageToken)}`,
          }
      };
      const response = await axios.post(`${API}/graphql`, payload, options);
      var queryResult = parseList(response, 200);
      
      return queryResult;

    } catch (error) {
      console.error(error);
      return null;
    }

  };

  const parseList = response => {
    if (response.status !== 200) throw Error(response.message);
    if (!response.data) return [];
    let list = response.data;
    if (typeof list !== 'object') {
      list = [];
    }
    return list;
  };

  const parseItem = (response, code) => {

    if (response.status !== code) throw Error(response.message);
    let item = response.data;

    if (typeof item !== 'object') {
      item = undefined;
    }
    return item;
  };
  
export const dataService = {
    signIn,

    executeQuery,
    getEntity,
 };
  