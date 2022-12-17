프레임 워크에 대격변이 필요, 현재 vue2 + typescript + webpack + npm +  파일복사 모듈 형식 사용

1. npm -> pnpm 으로 변경
- npm 패키지 설치 시 의존성 문제가 빈번하게 발생하고 각 프로젝트마다 하위에 모든 resource 를 다운로드하기 때문에 비효율적임
- pnpm 은 root project 에 스토어 형태로 저장, 하위 프로젝트는 참조형식임, 버전간 의존성 문제 해결
3. 파일복사에 심볼링크 모듈형식 -> turborepo 로 변경
- 각각의 프로젝트가 생성되는 것이 아니라, 한개의 프로젝트에서 main project 와 공통 영역을 구분하여 
5. webpack -> vite 로 변경
- 빌드 속도 및 생산성 향상 
7. vue2 + typescript -> nuxt3 (vue3) + typescript + pinia(store) 로 변경하면서 Composition API 사용
- server render 지원
- nuxt framework 사용으로인한 생산성 극대화 (component import, route 구현 , api fetch 등등)
- 상태 관리 store 가 product level 로 구현되는 것이 아니라 domain 단위로 구현 
  (board store, mail store, workflow store 가 아닌 article store, comment store, user store 등등 세분하게 구분함) 
- 기존 데코레이터를 사용하여 구현 @component, @Watch 등등
- Composition API 를 사용하여 구현부 단순화 + 재사용 증가
