/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 * @flow strict-local
 */

import React from 'react';
import OfflineCacheWebView from 'react-native-offline-cache-webview';
import {
  SafeAreaView,
  View,
  Dimensions,
  StatusBar
} from 'react-native';

import { WebView } from 'react-native-webview'; 

const App= () => {
  const windowHeight = Dimensions.get('window').height; 
  return (
    <>
      <StatusBar barStyle="dark-content" />
      <SafeAreaView>
          <View style={{height: '100%'}}>
            <WebView style={{height:windowHeight, flex:1}} source={{ uri: 'https://chicano.work' }} />
          </View>
      </SafeAreaView>
    </>
  );
};

export default App;
